using System;

namespace LedgerClient.Models {
	public class LedgerRecord {
		public string Id { get; set; }
		public DateTime Date { get; set; }
		public string ProductName { get; set; }
		public string Description { get; set; }

		public double Price { get; set; }
		public double Amount { get; set; }
		public string Сustomer { get; set; }

		public double AlexesMetPart { get; set; }
		public double CryptoGraphPart { get; set; }
		public double LogarithmusPart { get; set; }

		public string AmountAndPriceString { get => $"Amount: {Amount}, Price {Price} BYN"; }

	}
}