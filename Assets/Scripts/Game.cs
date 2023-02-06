using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject tile, tileWithPlayer, validTile;

    int playerRow = 0;
    int playerCol = 0;

    Board board;
    // Start is called before the first frame update
    void Start()
    {
        board = new Board(tile, tileWithPlayer, validTile);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (board.MovePiece(playerRow, playerCol, playerRow - 1, playerCol)) playerRow -= 1;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (board.MovePiece(playerRow, playerCol, playerRow + 1, playerCol)) playerRow += 1;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (board.MovePiece(playerRow, playerCol, playerRow, playerCol - 1)) playerCol -= 1;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (board.MovePiece(playerRow, playerCol, playerRow, playerCol + 1)) playerCol += 1;
        }
    }
}
