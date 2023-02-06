using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

/*
    The Board class deals with managing board state. When clicking a piece on the board, that piece should communicate to the board
    the specfic row and column that was clicked. 

    generateBoard() - should just be the constructor

    checkPiece()

    movePiece()

    addPiece()

    deletePiece()
*/       

public class Board : MonoBehaviour
{
    private GameObject[,] board = new GameObject[9, 9];
    private GameObject tile;
    private GameObject tileWithPlayer;
    private GameObject validTile;
    private const float _TILE_SIZE = .75f;

    private void Update() {

    }


    public Board(GameObject newTile, GameObject newTileWithPlayer, GameObject newValidTile) {
        tile = newTile; 
        tileWithPlayer = newTileWithPlayer;
        validTile = newValidTile;
        GenerateBoard();
        
    }

    private void GenerateBoard() {
        for (int row = 0; row < board.GetLength(0); row ++) {
            for (int col = 0; col < board.GetLength(1); col ++) {
                if (row == 0 && col == 0) {
                    GameObject player = Instantiate(tileWithPlayer, new Vector2(col * _TILE_SIZE, -row * _TILE_SIZE), Quaternion.identity);
                    board[row, col] = player;
                } else {
                    GameObject newTile = Instantiate(tile, new Vector2(col * _TILE_SIZE, -row * _TILE_SIZE), Quaternion.identity);
                    board[row, col] = newTile;
                }
            }
        }
    }

    public GameObject GetPiece(int row, int col) {
        return board[row, col];
    }

    public bool DeletePiece(int row, int col) {
        if (board[row, col] == null) return false;
        Destroy(board[row, col]);
        board[row, col] = null;
        return board[row, col] == null;
    }

    public bool AddPiece(int row, int col, GameObject prefab) {        
        board[row, col] = Instantiate(prefab, new Vector2(col * _TILE_SIZE, -row * _TILE_SIZE), Quaternion.identity);
        return board[row, col] != null;
    }

    public bool MovePiece(int oldRow, int oldCol, int newRow, int newCol) {
        if (oldRow >= board.GetLength(0) || 0 > oldRow || oldCol >= board.GetLength(1) || 0 > oldCol || newRow >= board.GetLength(0) || 0 > newRow || newCol >= board.GetLength(1) || 0 > newCol) return false;
        GameObject tokenToMove = GetPiece(oldRow, oldCol);
        
        DeletePiece(oldRow, oldCol);
        DeletePiece(newRow, newCol);
        AddPiece(oldRow, oldCol, tile);
        AddPiece(newRow, newCol, tokenToMove);
        return true;
    }
}

// TODO: Find out what actions occur when clicking on a spot in the board. When clicking on a spot, we have access to the 
// row and column of that spot, meaning we can check the token there. 

// A place on the board can either be OCCUPIED by a token, or null.