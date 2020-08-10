using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace BugExample
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly List<Item> _list = new List<Item>();

        public MainPage()
        {
            this.InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                Item item = new Item
                {
                    Image = new BitmapImage(new Uri("ms-appx:///Assets/G_ash.png")),
                    Text = i != 2 ? "×3" : "×15"
                };
                _list.Add(item);
            }
            GenerateItem();
        }

        private void GenerateItem()
        {
            var compositionChildren = CompositionWrapPanel.Children;
            compositionChildren.Clear();
            foreach (var item in _list)
            {
                var stackPanel = new StackPanel { Orientation = Orientation.Horizontal };
                var button = new Button
                {
                    Height = 50,
                    Width = 50,
                    BorderThickness = new Thickness(1),
                    Background = new SolidColorBrush(Colors.Transparent),
                    Margin = new Thickness(4, 0, 0, 0),
                    Style = Application.Current.Resources["ButtonRevealStyle"] as Style
                };
                var image = new Image
                {
                    Source = item.Image,
                    Height = 48,
                    Width = 48,
                    Margin = new Thickness(-9, -5, -9, -6),
                    Stretch = Stretch.Fill
                };
                button.Content = image;
                button.Tag = item;
                stackPanel.Children.Add(button);
                var textBlock = new TextBlock
                {
                    Text = item.Text,
                    FontSize = 20,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(4, 0, 0, 0)
                };
                stackPanel.Children.Add(textBlock);
                compositionChildren.Add(stackPanel);
            }
        }
    }
}
