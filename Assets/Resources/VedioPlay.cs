
/// <summary>
/// 视频播放辅助类
/// 作者：苏民 时间2016-12-28
/// </summary>
/// 
using UnityEngine;
using System.Collections;
using FairyGUI;

public static class VedioPlayHelper
    {
        /// <summary>
        /// 视频播放功能
        /// </summary>
        /// <param name="vedioName"></param>
        /// <param name="uiVedioPlay"></param>
        public static bool LoadMovieAndPlay(string vedioName, GameObject uiVedioPlay)
        {
            if (uiVedioPlay == null) return false;
            //如果重新选择学位就摧毁组件，重新添加VedioPlay组件
            if (uiVedioPlay.GetComponent<VedioPlay>() != null)
            {
                Object.Destroy(uiVedioPlay.GetComponent<VedioPlay>());
            }

            //获取最新的组件
            VedioPlay vedioPlayController = uiVedioPlay.AddComponent<VedioPlay>();
            vedioPlayController.IsDefaultPlay = true;
            vedioPlayController.Loop = true;
            vedioPlayController.VedioName = vedioName;

            Renderer[] renderers = uiVedioPlay.GetComponents<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                Material[] mats = renderer.sharedMaterials;
                foreach (var mat in mats)
                {
                    mat.SetFloat("_Metallic", 0f);
                }
            }

            return true;
        }
    }

    /// <summary>
    /// 视频播放
    /// 作者：苏民 时间2016-11-18
    /// </summary>
    public class VedioPlay : MonoBehaviour
    {
        /// <summary>
        /// 电影纹理贴图
        /// </summary>
        private MovieTexture _movieSource;

        /// <summary>
        /// 是否正在加载资源
        /// </summary>
        private bool _isLoading;

        /// <summary>
        /// 视频名称
        /// </summary>
        public string VedioName;

        /// <summary>
        /// 是否默认播放
        /// </summary>
        public bool IsDefaultPlay;

        /// <summary>
        /// 是否Loop播放
        /// </summary>
        public bool Loop = true;

        // ReSharper disable once UnusedMember.Local
        void Start()
        {
            if (IsDefaultPlay) Play();
        }

        IEnumerator LoadVedio(string vedioName)
        {
            _isLoading = true;
            //获取本地视频文件
            var video = Resources.LoadAsync( vedioName);
            while (!video.isDone)
            {
                yield return null;
            }
            _isLoading = false;
            _movieSource = video.asset as MovieTexture;
            if (_movieSource != null)
            {
                GetComponent<Renderer>().material.mainTexture = _movieSource;
                _movieSource.loop = Loop;
                _movieSource.Play();
            }
            yield return null;
        }

        public void Play()
        {
            if (_isLoading) return;
            if (string.IsNullOrEmpty(VedioName)) return;
            if (_movieSource != null) return;
            StartCoroutine(LoadVedio(VedioName));
        }

        public void Stop()
        {
            if (_isLoading) return;
            if (_movieSource == null) return;
            if (IsPlaying)
            {
                _movieSource.Stop();
                _movieSource = null;
            }
        }

        public bool IsPlaying
        {
            get
            {
                if (_isLoading) return true;
                if (_movieSource == null) return false;
                return _movieSource.isPlaying;
            }
        }

        public bool IsLoop
        {
            get
            {
                if (_movieSource == null) return false;
                return _movieSource.loop;
            }
        }
    }




