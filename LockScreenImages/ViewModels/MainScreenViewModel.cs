using Caliburn.Micro;
using LockScreenImages.Model;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace LockScreenImages.ViewModels
{
    class MainScreenViewModel : Screen
    {
        private BindableCollection<ImageModel> _images;
        private bool _isLoading;
        public MainScreenViewModel() { }

        public void ClickSave(ImageModel img)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Jpg (*.jpg)|*.jpg";
            saveFileDialog.DefaultExt = ".jpg";
            if (saveFileDialog.ShowDialog() == true)
            {
                Image imgSave = new Bitmap(img.Img);
                imgSave.Save(saveFileDialog.FileName);
            }
        }

        protected override void OnViewLoaded(object view)
        {
            IsLoading = true;
            Images = new BindableCollection<ImageModel>();

            var filePath = Environment.ExpandEnvironmentVariables(@"%userprofile%\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets");
            string[] filePaths = Directory.GetFiles(filePath, "*.*",
                                         SearchOption.TopDirectoryOnly);
            foreach (string item in filePaths)
            {
                FileInfo f = new FileInfo(item);
                if (f.Length > 70000)
                {
                    Images.Add(new ImageModel()
                    {
                        Img = item

                    });
                }
            }
            NotifyOfPropertyChange(() => Images);
            IsLoading = false;
        }

        public BindableCollection<ImageModel> Images
        {
            get { return _images; }
            set
            {
                _images = value;
                NotifyOfPropertyChange(() => Images);
            }
        }


        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                NotifyOfPropertyChange(() => IsLoading);
            }
        }


    }
}
