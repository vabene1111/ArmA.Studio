﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ArmA.Studio.Dialogs
{
    /// <summary>
    /// Interaction logic for FileEditorSelectorDialog.xaml
    /// </summary>
    public partial class ConfigEntrySelectorDialog : Window
    {
        public ConfigEntrySelectorDialog(ConfigEntrySelectorDialogDataContext dc)
        {
            this.DataContext = dc;
            this.InitializeComponent();
        }
    }
}
