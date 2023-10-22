using Microsoft.UI.Xaml;

namespace EstateZoningApp.ViewModels.Interfaces;
public interface ISaveChangesAware
{
    Task SaveChanges(XamlRoot root);
}
