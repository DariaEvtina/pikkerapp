using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PickerApp
{
    public partial class MainPage : ContentPage
    {
        TableView tv;
        public MainPage()
        {
           StackLayout st = new StackLayout();
           Button popup = new Button
            {
                Text = "Pickers",
                BackgroundColor = Color.CadetBlue
            };
            popup.Clicked += Popup_Clicked;
            st.Children.Add(popup);
            Content = st; 
        }

        private async void Popup_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Do you want open a Picker", "Cancel", "Yes", "No");
            if (result)
            { 
                string action = await DisplayActionSheet("Choose a Picker", "Cancel", null, "Counties Picker");
                if (action == "Counties Picker")
                {
                    await Navigation.PushAsync(new ContiesPicker());
                }
            }
            else
            { await DisplayAlert("", "The Solution is canceled", "Ok"); }
            
        }
    
    }
}
