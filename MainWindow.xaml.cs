// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

using Microsoft.UI.Xaml;

namespace Pong;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    /// <summary>
    /// Gets the pong runner.
    /// </summary>
    private Pong Pong { get; } = new Pong();

    public MainWindow()
    {
        this.InitializeComponent();
    }
}
