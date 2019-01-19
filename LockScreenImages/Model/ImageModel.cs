using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LockScreenImages.Model
{
    class ImageModel : PropertyChangedBase
    {
        
        private string _img;

        public string Img
        {
            get { return _img; }
            set
            {
                _img = value;
                NotifyOfPropertyChange(() => Img);
            }
        }

    }
}
