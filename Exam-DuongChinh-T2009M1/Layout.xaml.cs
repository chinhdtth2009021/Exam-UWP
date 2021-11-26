using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Exam_DuongChinh_T2009M1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Layout : Page
    {
        public Layout()
        {
            this.InitializeComponent();
        }
        private void MyNavView_BackRequested(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            MyNavView.IsBackEnabled = true;
            MyNavView.IsBackButtonVisible = NavigationViewBackButtonVisible.Visible;
            var tag = args.InvokedItemContainer.Tag.ToString();
            switch (tag)
            {
                case "add":
                    ContentPage.Navigate(typeof(Pages.AddContact), args.RecommendedNavigationTransitionInfo);
                    break;
                case "search":
                    ContentPage.Navigate(typeof(Pages.SearchContact), args.RecommendedNavigationTransitionInfo);
                    break;
            }
        }
        private void MyNavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (ContentPage.CanGoBack)
            {
                ContentPage.GoBack();
            }
        }
    }
}
