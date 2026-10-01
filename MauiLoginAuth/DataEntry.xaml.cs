using MauiLoginAuth.Models;
using MauiLoginAuth.DataAccess;

namespace MauiLoginAuth;

public partial class DataEntry : ContentPage
{
	public DataEntry()
	{
		InitializeComponent();
	}

	private async void OnSaveClicked(object sender, EventArgs e)
	{
		//Check for empty fields
		if (string.IsNullOrWhiteSpace(txtItemId.Text) ||
			string.IsNullOrWhiteSpace(txtItemName.Text) ||
			string.IsNullOrWhiteSpace(txtItemDescription.Text))
		{
			await DisplayAlert("Missing Information", "Please fill in all fields.", "OK");
			return;
		}

		//Check ITemId is a valid integer
		if (!int.TryParse(txtItemId.Text, out int itemId))
		{
			await DisplayAlert("Invalid Input", "Item ID must be a valid integer.", "OK");
			return;
		}
		//Create a new item object
		var item = new Item
		{
			ItemId = itemId,
			ItemName = txtItemName.Text,
			ItemDescription = txtItemDescription.Text
		};

		//Save the item using the data access class
		var dataAccess = new ItemDataAccess();
		bool isSaved = await dataAccess.SaveItemAsync(item);

		if (isSaved)
		{
			await DisplayAlert("Success", "Item saved successfully.", "OK");

            //Retieve all items from the Web API and display in the collection view
            var items = await dataAccess.GetItems();

            //Display in collection view
			StoredItemsList.ItemsSource = items;

            // Clear the entry fields after successful save
            txtItemId.Text = string.Empty;
			txtItemName.Text = string.Empty;
			txtItemDescription.Text = string.Empty;
		}
		else
		{
			await DisplayAlert("Error", "Failed to save the item. Please try again.", "OK");
		}
	}

    private void OnCancelClicked(object sender, EventArgs e)
	{
		// Clear the entry fields
		txtItemId.Text = string.Empty;
		txtItemName.Text = string.Empty;
        txtItemDescription.Text = string.Empty;
    }
}