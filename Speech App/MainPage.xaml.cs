using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Speech_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void sayText_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(text.Text))
            {
                MediaElement mediaElement = new MediaElement();
                Windows.Media.SpeechSynthesis.SpeechSynthesizer speech = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
                Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await
                speech.SynthesizeTextToStreamAsync("Please input your text in the input text box");
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play();
            }
            else
            {
                MediaElement mediaElement = new MediaElement();
                var speech = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
                Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await
                speech.SynthesizeTextToStreamAsync(text.Text);
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play();
            }
        }
    }
}
