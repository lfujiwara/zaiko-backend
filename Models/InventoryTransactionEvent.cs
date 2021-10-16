

using System;

namespace Zaiko.Models
{
    public class InventoryTransactionEvent : InventoryEvent
    {
        public Sheet Origin { get; private set; }

        public Sheet Destination { get; private set; }

    }
}