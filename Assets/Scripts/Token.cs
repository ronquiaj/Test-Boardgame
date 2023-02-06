using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// Each turn, a player can either place a token or use an existing token. When using an existing token, 
// that token can either move or it can attack.

interface IToken {
    int Health { get; set; }
    int Attack { get; set; }
}

public class Token: MonoBehaviour, IToken {
    public Token(int health, int attack) {
        Health = health;
        Attack = attack;
    }

    private void Update() {
        
    }

    void OnMouseOver() {
        if (Input.GetMouseDown(0)) {
            Debug.Log("Clicked");
        }
    }

    public int Health {get; set;}
    public int Attack {get; set;}
}
