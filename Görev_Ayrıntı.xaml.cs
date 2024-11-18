using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp5;

public partial class Görev_Ayrıntı : ContentPage
{
    public bool Result = false;
  
    bool edit = false;

    public Görev_Ayrıntı()
    {
        InitializeComponent();

    }

    private void TAMAMClicked(object sender, EventArgs e)
    {
        Result = true;
    
        if (!edit)
        {
           
        }

        Navigation.PopModalAsync();
    }

    private void İPTALClicked(object sender, EventArgs e)
    {
        Result = false;
        Navigation.PopModalAsync();
    }


}