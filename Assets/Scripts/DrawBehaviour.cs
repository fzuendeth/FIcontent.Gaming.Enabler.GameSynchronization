﻿/* Copyright (c) 2013 Disney Research Zurich and ETH Zurich
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawBehaviour : MonoBehaviour
{
    private static Color[] playerColors = new Color[]
    {
        Color.red,
        Color.blue
    };
        
    private static Queue toDraw = new Queue();

    public GameObject prefab;

    public void Update()
    {
        if (toDraw.Count > 0)
        {
            var action = toDraw.Dequeue() as DrawPointAction;
            var g = Instantiate(prefab, action.position, Quaternion.identity) as GameObject;
           g.GetComponentInChildren<Renderer>().material.color = playerColors[action.PID - 1];           
        }
    }

    public static void Draw(DrawPointAction action)
    {
        toDraw.Enqueue(action);
    }  
}
