﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        SceneTransition.SwitchToScene(sceneName);
    }
}
