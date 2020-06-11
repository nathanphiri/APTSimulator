using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace APTSimulator
{
    /// <summary>
    /// Interaction logic for QuestionViewWPF.xaml
    /// </summary>
    public partial class QuestionViewWPF : UserControl
    {
        
        TimeSpan duration;
        private bool validTimer = false;

        public event EventHandler OnTimeUp;


        public void InvalidateTimer()
        {
            validTimer = false;
        }

        public QuestionViewWPF()
        {
            InitializeComponent();
        }

        public void SetElapsedTime(TimeSpan elapsed)
        {
            if (validTimer)
            {
                TimeSpan remaining = duration - elapsed;

                if (remaining.TotalSeconds <= 0)
                {
                    remaining = new TimeSpan();

                    OnTimeUp?.Invoke(this, null);
                    InvalidateTimer();

                }
                lblRemainingTime.Content = remaining.ToString(@"hh\:mm\:ss");
            }
        }
        public void SetCategory(string categoryText)
        {
            categoryTextBlock.Text = categoryText;
        }
        public void SetSectionDescription(string desc)
        {
            lblSectionDescription.Content = desc;
        }

        public TextBlock Question { get {
                return questionTextBlock;
            } }
        public Button FirstAnswer { get {
                return firstAnswer;
            } }

        public Button SecondAnswer { get {
                return secondAnswer;
            } }

        public Button ThirdAnswer { get {
                return thirdAnswer;
            } }

        public Label QuestionNo { get {
                return lblQuestionNo;
            } }
        public void setIllustration(System.Drawing.Image image)
        {
            if(image == null)
            {
                illustration.Source = null;
            }
            else
            {
                illustration.Source = ConvertImage(image);
            }
        }
        public static System.Windows.Media.ImageSource ConvertImage(System.Drawing.Image image)
        {
            try
            {
                if (image != null)
                {
                    var bitmap = new System.Windows.Media.Imaging.BitmapImage();
                    bitmap.BeginInit();
                    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                    image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                    bitmap.StreamSource = memoryStream;
                    bitmap.EndInit();
                    return bitmap;
                }
            }
            catch { }
            return null;
        }

        public void SetCategoryTimeLimit(TimeSpan timespan)
        {
            duration = timespan;
            lblTimeLimit.Content = timespan.ToString("c");
            validTimer = true;
        }

    }
}
