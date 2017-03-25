using MyEvents.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyEvents
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var mainPage = new TabbedPage();
            var sessionsPage = new NavigationPage(new SessionsPage()) { Title = "Sessions" };
            // declare speakersPage here
            var aboutPage = new NavigationPage(new AboutPage()) { Title = "About" };
            //dev speakersPage
            var speakersPage = new NavigationPage(new SpeakersPage()) { Title = "Speakers" };

            mainPage.Children.Add(sessionsPage);
            //add speakersPage here
            //dev add speakers page
            mainPage.Children.Add(speakersPage);
            mainPage.Children.Add(aboutPage);

            MainPage = mainPage;

            Device.OnPlatform(iOS: () => {
                sessionsPage.Icon = "tab_feed.png";
                speakersPage.Icon = "tab_person.png";
                aboutPage.Icon = "tab_about.png";

            });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
