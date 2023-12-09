using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;
using ImageCompression.Common;
using ImageCompression.Metrics;
using ImageCompression.Compression_Method;
using System.Windows.Interop;
using System.Diagnostics;
using ImageCompression.Common.ColorSpace;

namespace ImageCompression
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Picture Pic { get; set; }//исходное изображение
        public Picture ConvertPic { get; set; }//преобразованное изображение
        public HaarWavelet HaarWavelet { get; set; }
        public DaubechiWavelet DaubechiWavelet { get; set; }
        public DCT DCT { get; set; }
        public string Method { get; set; }
        public string PercentZeroPx { get; set; }
        public string ImagePath { get; set; }
        public CompressionSettings Settings { get; set; }
        private Stopwatch Stopwatch { get; set; }
        public MainWindow()
        {
            Settings = new CompressionSettings();
            Stopwatch = new Stopwatch();
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdPicture = new OpenFileDialog();
            ofdPicture.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            ofdPicture.FilterIndex = 1;

            if (ofdPicture.ShowDialog() == true)
            InitImage.Source = new BitmapImage(new Uri(ofdPicture.FileName));
            //ConvertImage.Source = new BitmapImage(new Uri(ofdPicture.FileName));
            ImagePath = ofdPicture.FileName;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(new Uri(ofdPicture.FileName)));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);
                Pic = new Picture(bitmap);

            }
            FileInfo.Content =
                "Path: " + ofdPicture.FileName +
                "\nFile name:" + ofdPicture.SafeFileName +
                "\nSize:" + Pic.Width.ToString() + " x " + Pic.Height.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Bitmap bitmap = Pic.ToBitmap();
            bitmap.Save(ImagePath);
        }

        private void SaveAsButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfdPicture = new SaveFileDialog();
            sfdPicture.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            sfdPicture.Title = "Save an Image File";
            if (sfdPicture.ShowDialog() != null)
            {
                Bitmap bitmap = ConvertPic.ToBitmap();
                bitmap.Save(sfdPicture.FileName);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            InitImage.Source = null;
            ConvertImage.Source = null;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CompressionMethodComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CompressionMethodComboBox.SelectedIndex == 0) 
            { 
                Method = "Вейвлет Хаара"; 
                CompressionMethodComboBox.Text= Method;
                AdditionalCompressing.Visibility= Visibility.Visible;
            }
            if (CompressionMethodComboBox.SelectedIndex == 1) 
            { 
                Method = "Вейвлет Добеши";
                CompressionMethodComboBox.Text = Method;
                AdditionalCompressing.Visibility = Visibility.Visible;
            }
            if (CompressionMethodComboBox.SelectedIndex == 2) 
            { 
                Method = "Дискретно-косинусное преобразование";
                CompressionMethodComboBox.Text = Method;
                AdditionalCompressing.Visibility = Visibility.Hidden;
            }
        }

        private void AdditionalCompressing_Checked(object sender, RoutedEventArgs e)
        {
            if (AdditionalCompressing.IsChecked == true)
            {
                Settings.AdditionalCompression = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (InitImage.Source == null)
            {
                MessageBox.Show("Выберите изображение.");
            }
            else
            {
                switch (Method)
                {
                    case "Вейвлет Хаара":
                        HaarWavelet = new HaarWavelet(Pic, Settings);
                        Stopwatch.Start();
                        HaarWavelet.HaarConversation();
                        Stopwatch.Stop();
                        AlgorithmInfo.Content = "Использованный алгоритм: Вейвлет Хаара\nВремя работы алгоритма прямого преобразования(в мс):" + Stopwatch.ElapsedMilliseconds.ToString();
                        Stopwatch = new Stopwatch();
                        ConvertPic = HaarWavelet.pic;
                        
                        ConvertImage.Source = Imaging.CreateBitmapSourceFromHBitmap(
                            ConvertPic.ToBitmap().GetHbitmap(),
                            IntPtr.Zero,
                            Int32Rect.Empty,
                            BitmapSizeOptions.FromEmptyOptions());

                        break;
                    case "Вейвлет Добеши":
                        DaubechiWavelet = new DaubechiWavelet(Pic, Settings);
                        Stopwatch.Start();
                        DaubechiWavelet.DaubechiConversation();
                        Stopwatch.Stop();
                        AlgorithmInfo.Content = "Использованный алгоритм: Вейвлет Добеши\nВремя работы алгоритма прямого преобразования(в мс):" + Stopwatch.ElapsedMilliseconds.ToString();
                        ConvertPic = DaubechiWavelet.pic;

                        ConvertImage.Source = Imaging.CreateBitmapSourceFromHBitmap(
                            ConvertPic.ToBitmap().GetHbitmap(),
                            IntPtr.Zero,
                            Int32Rect.Empty,
                            BitmapSizeOptions.FromEmptyOptions());
                        break;
                    case "Дискретно-косинусное преобразование":
                        DCT = new DCT(Pic, Settings);
                        Stopwatch.Start();
                        DCT.Conversation();
                        Stopwatch.Stop();
                        AlgorithmInfo.Content = "Использованный алгоритм: Дискретно-косинусное преобразование\nВремя работы алгоритма прямого преобразования(в мс):" + Stopwatch.ElapsedMilliseconds.ToString();
                        ConvertPic = new Picture(DCT.ToBitmap());
                        ConvertImage.Source = Imaging.CreateBitmapSourceFromHBitmap(
                            ConvertPic.ToBitmap().GetHbitmap(),
                            IntPtr.Zero,
                            Int32Rect.Empty,
                            BitmapSizeOptions.FromEmptyOptions());
                        break;
                }
            }
        }

        private void QuantCoefficient_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (QuantCoefficient.Text.Length > 0)
            {
                Settings.QuantCoef = Convert.ToDouble(QuantCoefficient.Text);
            }
        }

        
        private void RevConversationButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConvertImage.Source == null)
            {
                MessageBox.Show("Выберите изображение.");
            }
            else
            {
                switch (Method)
                {
                    case "Вейвлет Хаара":
                        Stopwatch.StartNew();
                        HaarWavelet.HaarRevConversation();
                        Stopwatch.Stop();
                        AlgorithmInfo.Content += "\nВремя работы алгоритма обратного преобразования (в мс):" + Stopwatch.ElapsedMilliseconds.ToString();
                        ConvertPic = HaarWavelet.pic;
                        ConvertImage.Source = Imaging.CreateBitmapSourceFromHBitmap(
                            ConvertPic.ToBitmap().GetHbitmap(),
                            IntPtr.Zero,
                            Int32Rect.Empty,
                            BitmapSizeOptions.FromEmptyOptions());

                        break;
                    case "Вейвлет Добеши":
                        Stopwatch.StartNew();
                        DaubechiWavelet.DaubechiRevConversation();
                        Stopwatch.Stop();
                        AlgorithmInfo.Content += "\nВремя работы алгоритма обратного преобразования (в мс):" + Stopwatch.ElapsedMilliseconds.ToString();
                        ConvertPic = DaubechiWavelet.pic;
                        var k=Metric.MSE(Pic, ConvertPic);
                        ConvertImage.Source = Imaging.CreateBitmapSourceFromHBitmap(
                            ConvertPic.ToBitmap().GetHbitmap(),
                            IntPtr.Zero,
                            Int32Rect.Empty,
                            BitmapSizeOptions.FromEmptyOptions());
                        break;
                    case "Дискретно-косинусное преобразование":
                        Stopwatch.StartNew();
                        ConvertPic = DCT.RevConversation();
                        Stopwatch.Stop();
                        AlgorithmInfo.Content += "\nВремя работы алгоритма обратного преобразования (в мс):" + Stopwatch.ElapsedMilliseconds.ToString();
                        ConvertImage.Source = Imaging.CreateBitmapSourceFromHBitmap(
                            ConvertPic.ToBitmap().GetHbitmap(),
                            IntPtr.Zero,
                            Int32Rect.Empty,
                            BitmapSizeOptions.FromEmptyOptions());
                        break;
                }
            }
            Settings = new CompressionSettings();
            CompressionMethodComboBox.SelectedItem = null;
            AdditionalCompressing.Visibility = Visibility.Hidden;
            QuantCoefficient.Text = "";
            CompressionMethodComboBox.Text = "";
            PercentZeroPxResult.Visibility = Visibility.Hidden;
        }

        private void AnalysisButton_Click(object sender, RoutedEventArgs e)
        {
            Pic.RevBrghtnessShift();
            MSEResult.Content = "MSE: " + Metric.MSE(Pic, ConvertPic).ToString();
            RSNRResult.Content = "PSNR:" + Metric.PSNR(Pic, ConvertPic).ToString();
            if (Method != "Дискретно-косинусное преобразование")
            {
                PercentZeroPxResult.Visibility = Visibility.Visible;
                PercentZeroPxResult.Content = PercentZeroPx;
            }
        }
    }
}
