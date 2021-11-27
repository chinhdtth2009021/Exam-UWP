using Exam_DuongChinh_T2009M1.Entities;
using Exam_DuongChinh_T2009M1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Contact = Exam_DuongChinh_T2009M1.Entities.Contact;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Exam_DuongChinh_T2009M1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddContact : Page
    {
        private ContactModel contactModel = new ContactModel();
        public AddContact()
        {
            this.InitializeComponent();
            this.Loaded += AddContacts_Loaded;
            SharedShadow.Receivers.Add(BackgroundGrid);
            AddForm.Translation += new Vector3(120, 0, 32);
        }

        private void AddContacts_Loaded(object sender, RoutedEventArgs e)
        {
            DatabaseMigration.UpdateDabase();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var contact = new Contact()
            {
                phoneNumber = txtPhoneNumber.Text,
                name = txtName.Text
            };
            var resutl = contactModel.Save(contact);
            ContentDialog contentDialog = new ContentDialog();
            if (resutl)
            {
                contentDialog.Title = "Actions success";
                contentDialog.Content = "Contact Saved!";
                contentDialog.PrimaryButtonText = "Ok";
                await contentDialog.ShowAsync();
            }
            else
            {
                contentDialog.Title = "Actions fails";
                contentDialog.Content = "Please try again!";
                contentDialog.PrimaryButtonText = "Ok";
                await contentDialog.ShowAsync();
            }
        }
    }
}

