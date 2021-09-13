using LedgerClient.Services;
using LedgerClient.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LedgerClient {
	public partial class App : Application {

		public static GoogleSheets.Client GoogleSheetsClient = new GoogleSheets.Client();

		public App() {
			InitializeComponent();

			DependencyService.Register<DataStore>();

			MainPage = new AppShell();
		}

		protected override void OnStart() {
		}

		protected override void OnSleep() {
		}

		protected override void OnResume() {
		}
	}
}
