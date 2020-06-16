﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
using ModernWpf;
using ModernWpf.Controls;

namespace WPFModernUITest
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        //Dark Theme Button
        private void DarkTheme_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
            SaveSettings();
        }

        //Light Theme Button
        private void LightTheme_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
            SaveSettings();
        }

        //Default Button Click
        private void DefaultTheme_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ApplicationTheme = null;
            SaveSettings();
        }

        //Save settings on close of flyout
        private void AccentColorFlyout_Closed(object sender, object e)
        {
            SaveSettings();
        }

        //Save Settings Method
        public void SaveSettings()
        {
            if (SettingsUIUC.Visibility == Visibility.Visible)
            {
            string AccentColor, CurrentTheme;

            //Color color2 = (Color)ColorConverter.ConvertFromString("#FF0063B1");

            if (DefaultTheme.IsChecked == true)
            {
                CurrentTheme = "null";
            }  
            else
            { 
                CurrentTheme = Convert.ToString(ThemeManager.Current.ActualApplicationTheme);
            }
            AccentColor = Convert.ToString(ThemeManager.Current.AccentColor);

            string[] lines = { "[Theme]", CurrentTheme, "[Accent Color]", AccentColor };
            System.IO.File.WriteAllLines(@"Settings.ini", lines);
            }
        }
    }
}