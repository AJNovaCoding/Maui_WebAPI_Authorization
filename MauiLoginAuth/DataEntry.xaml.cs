namespace MauiLoginAuth;

public partial class DataEntry : ContentPage
{
	public DataEntry()
	{
		InitializeComponent();
	}

	private async void OnSaveClicked(object sender, EventArgs e)
	{
		await DisplayAlert("Data Saved", "Your data has been saved successfully.", "OK");
    }

	private void OnCancelClicked(object sender, EventArgs e)
	{
		// Clear the entry fields
		txtItemId.Text = string.Empty;
		txtItemName.Text = string.Empty;
        txtItemDescription.Text = string.Empty;
    }
}