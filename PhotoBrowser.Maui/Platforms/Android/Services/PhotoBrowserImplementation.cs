using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.ViewPager.Widget;
using AndroidX.ViewPager2.Widget;
using GPSMobile.BA;
using Microsoft.Maui;
using Microsoft.Maui.Platform;
using PhotoBrowser.Maui.Platforms.Android;
using PhotoBrowser.Maui.Platforms.Android.ImageGallery;
using Resource = Microsoft.Maui.Resource;
using Application = Android.App.Application;
using Android.OS;
using Java.Util;

namespace PhotoBrowsers.Platforms.Android
{
    public class PhotoBrowserImplementation : IPhotoBrowser
    {
        public static PhotoBrowser photoBrowser;
        public void Show(PhotoBrowser _photoBrowser)
        {
            Intent intent = new Intent(Application.Context, typeof(GallerySlideActivity));
            intent.AddFlags(ActivityFlags.NewTask);
            Bundle b = new Bundle();
            b.PutStringArrayList("PhotoBrowser", _photoBrowser.Photos.Select(x => x.URL).ToArray());
            b.PutInt("PhotoBrowserIndex", _photoBrowser.StartIndex);
            intent.PutExtras(b);
            photoBrowser = _photoBrowser;
            Application.Context.StartActivity(intent);
        }
        public void Close()
        {
        }
    }
}