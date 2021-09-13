using LedgerClient.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LedgerClient.Views {
	public partial class ItemDetailPage : ContentPage {
		public ItemDetailPage() {
			InitializeComponent();
			BindingContext = new ItemDetailViewModel();
		}
	}
}