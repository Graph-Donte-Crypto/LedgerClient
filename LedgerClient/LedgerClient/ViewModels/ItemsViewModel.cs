using LedgerClient.Models;
using LedgerClient.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LedgerClient.ViewModels {
	public class ItemsViewModel : BaseViewModel {
		private LedgerRecord _selectedItem;

		public ObservableCollection<LedgerRecord> Items { get; }
		public Command LoadItemsCommand { get; }
		public Command AddItemCommand { get; }
		public Command<LedgerRecord> ItemTapped { get; }

		public ItemsViewModel() {
			Title = "Browse";
			Items = new ObservableCollection<LedgerRecord>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

			ItemTapped = new Command<LedgerRecord>(OnItemSelected);

			AddItemCommand = new Command(OnAddItem);
		}

		async Task ExecuteLoadItemsCommand() {
			IsBusy = true;

			try {
				Items.Clear();
				var items = await DataStore.GetItemsAsync(true);
				foreach (var item in items) {
					Items.Add(item);
				}
			} catch (Exception ex) {
				Debug.WriteLine(ex);
			} finally {
				IsBusy = false;
			}
		}

		public void OnAppearing() {
			IsBusy = true;
			SelectedItem = null;
		}

		public LedgerRecord SelectedItem {
			get => _selectedItem;
			set {
				SetProperty(ref _selectedItem, value);
				OnItemSelected(value);
			}
		}

		private async void OnAddItem(object obj) {
			await Shell.Current.GoToAsync(nameof(NewItemPage));
		}

		async void OnItemSelected(LedgerRecord item) {
			if (item == null)
				return;

			// This will push the ItemDetailPage onto the navigation stack
			await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
		}
	}
}