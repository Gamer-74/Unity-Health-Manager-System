using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrueTacticalStudio
{
    public interface IHealthManager
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public bool IsHealthEmpty { get; set; }
    }
}