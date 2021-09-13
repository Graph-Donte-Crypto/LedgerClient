using LedgerClient.Models;
using LedgerClient.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LedgerClient.Views {
	public partial class NewItemPage : ContentPage {
		public LedgerRecord Item { get; set; }

		public NewItemPage() {
			InitializeComponent();
			BindingContext = new NewItemViewModel();
		}
	}
}