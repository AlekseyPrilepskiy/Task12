using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColorChangeNotifier
{
    public event Action StatusChanged;
}
