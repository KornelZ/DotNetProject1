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

namespace LGSA.View
{
    /// <summary>
    /// Interaction logic for AddProductDialog.xaml
    /// </summary>
    public partial class AddProductDialog : Window
    {
        public AddProductDialog()
        {
            InitializeComponent();
        }

        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
        private void CancelButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
