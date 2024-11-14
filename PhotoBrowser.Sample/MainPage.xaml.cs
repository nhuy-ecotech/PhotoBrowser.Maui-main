using System.Diagnostics;
using System.Net;
using PhotoBrowsers;

namespace PhotoBrowser.Sample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            new PhotoBrowsers.PhotoBrowser
            {
                Photos = new List<Photo>
                {
                   new Photo
                    {
                        URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Vincent.jpg",
                        Title = "Vincent"
                    },
                    new Photo
                    {
                        URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Jules.jpg",
                        Title = "Jules"
                    },
                    new Photo
                    {
                        URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Korben.jpg",
                        Title = "Korben"
                    },
                    new Photo
                    {
                        URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Toretto.jpg",
                        Title = "Toretto"
                    },
                    new Photo
                    {
                        URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Marty.jpg",
                        Title = "Marty"
                    },
                    new Photo
                    {
                        URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Driver.jpg",
                        Title = "Driver"
                    },
                    new Photo
                    {
                        URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Frank.jpg",
                        Title = "Frank"
                    },
                    new Photo
                    {
                        URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Max.jpg",
                        Title = "Max"
                    },
                    new Photo
                    {
                        URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Daniel.jpg",
                        Title = "Daniel"
                    }
                },
                StartIndex = 3,
                ActionButtonPressed = (index) =>
                {

                    shareImage("https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Daniel.jpg");
                }
            }.Show();
        }

        private void OnCounterClicked2(object sender, EventArgs e)
        {
            new PhotoBrowsers.PhotoBrowser
            {
                Photos = new List<Photo>
                {
                   new Photo
                    {
                        URL = "https://s3.ap-southeast-1.amazonaws.com/bigdata-data-bucket/quality-app/12-11-2024/3_QCRecord_ImageVideo_61a4ca81-cb1d-48cf-b1e7-8893d99eacd5.jpg",
                        Title = "Vincent"
                    },
                    new Photo
                    {
                        URL = "https://s3.ap-southeast-1.amazonaws.com/bigdata-data-bucket/quality-app/12-11-2024/3_QCRecord_ImageVideo_25698497-4d43-4fd9-aa16-0962e53a6e1e.jpg",
                        Title = "Jules"
                    }
                },
                StartIndex = 0,
            }.Show();
        }
        public static async void shareImage(string _path)
        {
            try
            {
                if (!string.IsNullOrEmpty(_path))
                {
                    string fileName = _path.Split('/').ToList().Last();

                    var pathFile = Path.Combine(FileSystem.CacheDirectory, fileName);
                    if (!File.Exists(pathFile))
                    {
                        File.WriteAllBytes(pathFile, await DownloadFileAsync(_path));
                    }

                    await Share.RequestAsync(new ShareFileRequest
                    {
                        Title = "Chia sẻ ảnh",
                        File = new ShareFile(pathFile)
                    });
                }
            }
            catch (Exception ex)
            {

            }
        }
        // Download file
        public static async Task<byte[]> DownloadFileAsync(string fullPath)
        {
            var _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(120) };
            try
            {
                using (var httpResponse = await _httpClient.GetAsync(fullPath))
                {
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        return await httpResponse.Content.ReadAsByteArrayAsync();
                    }
                    else
                    {
                        //Url is Invalid
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                //Handle Exception
                return null;
            }
        }
    }

}
