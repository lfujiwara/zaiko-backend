namespace Zaiko.Models
{
    public class InventoryCheckEvent : InventoryEvent
    {
        public Sheet Sheet { get; private set; }
    }
}