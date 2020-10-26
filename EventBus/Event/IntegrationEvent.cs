using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Event
{
    public class IntegrationEvent
    {

        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }



        [JsonProperty]
        public Guid Id { get; private set; }

        [JsonProperty]
        public DateTime CreationDate { get; private set; }
    }
}
