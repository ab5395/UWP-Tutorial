using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloWorld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static IReadOnlyList<StorageFile> PPTFiles = new List<StorageFile>();
        public static StorageFolder DestinationFolder;
        public string FileSuffixName = string.Empty;
        public static string colorName = string.Empty;
        public static int PresentationHeight = 0, PresentationWidth = 0, X = 0, Y = 0, WatermarkWidth = 0, WatermarkHeight = 0;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void BtnPresentationFile_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            openPicker.FileTypeFilter.Add(".ppt");
            openPicker.FileTypeFilter.Add(".pptx");
            var PPTFiles = await openPicker.PickMultipleFilesAsync();
            if (PPTFiles != null && PPTFiles.Count > 0)
            {
                txtPresentationInput.Text = "Total Files: " + PPTFiles.Count + " files selected.";
            }
            else
            {
                txtPresentationInput.Text = string.Empty;
            }
        }

        private async void BtnDestinationFolder_Click(object sender, RoutedEventArgs e)
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker
            {
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop
            };
            folderPicker.FileTypeFilter.Add("*");
            DestinationFolder = await folderPicker.PickSingleFolderAsync();
            if (DestinationFolder != null)
            {
                Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", DestinationFolder);
                txtDestinationInput.Text = "Picked folder: " + DestinationFolder.Name;
            }
            else
            {
                txtDestinationInput.Text = "Operation cancelled.";
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (spCustomPresentationTime != null)
            {
                spCustomPresentationTime.Visibility = rbDefaultPresentationTime.IsChecked == false ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void Watermark_Checked(object sender, RoutedEventArgs e)
        {
            if (spWatermarkText != null && spWatermarkImage != null)
            {
                if (rbWatermarkText.IsChecked == true)
                {
                    spWatermarkText.Visibility = Visibility.Visible;
                    spWatermarkImage.Visibility = Visibility.Collapsed;
                }
                else
                {
                    spWatermarkText.Visibility = Visibility.Collapsed;
                    spWatermarkImage.Visibility = Visibility.Visible;
                }
            }
        }

        private async void btncolorpicker_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog color = new ColorDialog();
            await color.ShowAsync();
        }

        private void CbWatermarkPosition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region Position
            /*
            "Top-Right",
            "Top-Center",
            "Top-Left",
            "Center-Right",
            "Center",
            "Center-Left",
            "Bottom-Right",
            "Bottom-Center",
            "Bottom-Left"
             */
            #endregion
            if (rbWatermarkText.IsChecked == true)
            {

            }
            else
            {
                if (txtWatermarkImage.Text != string.Empty)
                {
                    switch (cbWatermarkPosition.SelectedIndex)
                    {
                        case 0:
                            X = PresentationWidth - WatermarkWidth;
                            Y = 1;
                            break;
                        case 1:
                            X = PresentationWidth / 2 - WatermarkWidth / 2;
                            Y = 1;
                            break;
                        case 2:
                            X = 1;
                            Y = 1;
                            break;
                        case 3:
                            X = PresentationWidth - WatermarkWidth;
                            Y = PresentationHeight / 2 - WatermarkHeight / 2;
                            break;
                        case 4:
                            X = PresentationWidth / 2 - WatermarkWidth / 2;
                            Y = PresentationHeight / 2 - WatermarkHeight / 2;
                            break;
                        case 5:
                            X = 1;
                            Y = PresentationHeight / 2 - WatermarkHeight / 2;
                            break;
                        case 6:
                            X = PresentationWidth - WatermarkWidth;
                            Y = PresentationHeight - WatermarkHeight;
                            break;
                        case 7:
                            X = PresentationWidth / 2 - WatermarkWidth / 2;
                            Y = PresentationHeight - WatermarkHeight;
                            break;
                        case 8:
                            X = 1;
                            Y = PresentationHeight - WatermarkHeight;
                            break;
                    }
                }
            }
        }




        private void CbPresentationSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbPresentationSize.SelectedIndex)
            {
                case 0:
                    PresentationHeight = 240;
                    PresentationWidth = 320;
                    break;
                case 1:
                    PresentationHeight = 640;
                    PresentationWidth = 320;
                    break;
                case 2:
                    PresentationHeight = 480;
                    PresentationWidth = 640;
                    break;
                case 3:
                    PresentationHeight = 480;
                    PresentationWidth = 720;
                    break;
                case 4:
                    PresentationHeight = 600;
                    PresentationWidth = 800;
                    break;
                case 5:
                    PresentationHeight = 576;
                    PresentationWidth = 900;
                    break;
                case 6:
                    PresentationHeight = 720;
                    PresentationWidth = 1080;
                    break;
                case 7:
                    PresentationHeight = 720;
                    PresentationWidth = 1280;
                    break;
            }
        }
    }
}
