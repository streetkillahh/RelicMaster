using Microsoft.Extensions.DependencyInjection;
using RelicMaster.DAL;
using RelicMaster.Domain.Entity;
using System.Linq;
using System.Windows;

namespace RelicMaster;

public partial class MainWindow : Window
{
    private readonly ApplicationDbContext _context;

    public MainWindow(ApplicationDbContext context)
    {
        InitializeComponent();
        _context = context;

        // Adding a sample relic
        var relic = new Relic { Name = "Sample Relic", Price = 9.99m };
        _context.Relics.Add(relic);
        _context.SaveChanges();

        // Fetching all relics
        var relics = _context.Relics.ToList();
        DataContext = new MainViewModel { Relics = relics };
    }
}

public class MainViewModel
{
    public List<Relic> Relics { get; set; }
}
