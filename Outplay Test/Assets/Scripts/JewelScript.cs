using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This has just been commented out to prevent errors and allow the game for question 4 to play

/*public class Board
{
    enum JewelKind
    {
        Empty,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    };

    enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right
    };

    public class Move
    {
        public float x;
        public float y;
        public MoveDirection direction;
        public int priority;
    };

    int GetWidth();
    int GetHeight();

    JewelKind GetJewel(float x, float y);
    void SetJewel(float x, float y, JewelKind kind);

    
    public Move CalculateBestMoveForBoard()
    {
        // Create an array of all jewels on the board
        JewelKind[,] jewels = new JewelKind[GetWidth(), GetHeight()];
        // Create a list of possible moves
        List<Move> possibleMoves = new List<Move>();

        // Populate the array
        for (int i = 0; i < GetWidth(); i++)
        {
            for (int j = 0; j < GetHeight(); j++)
            {
                jewels[i, j] = GetJewel(i, j);
            }
        }

        // Swap each jewel in every possible direction and check for matches
        for (int i = 0; i < GetWidth(); i++)
        {
            for (int j = 0; j < GetHeight(); j++)
            {
                // Swap this jewel with the one above it
                if (j > 0)
                {
                    // Store the new coordinates and current coordinates so these can be changed back later
                    Vector2 newCoordinates = new Vector2(i, j - 1);
                    Vector2 oldCoordinates = new Vector2(i, j);

                    // Create a new Move instance for this particular move
                    Move move = new Move();
                    move.x = oldCoordinates.x;
                    move.y = oldCoordinates.y;
                    move.direction = MoveDirection.Up;

                    // Set the jewel to be up one space
                    SetJewel(newCoordinates.x, newCoordinates.y, jewels[i, j]);
                    // Set the replaced jewel to be down one space
                    SetJewel(oldCoordinates.x, oldCoordinates.y, jewels[i, j - 1]);

                    // Check if the two jewels to the right of the swapped jewel are the same type, i.e. a match occurs
                    if (newCoordinates.x + 1 < GetWidth() && jewels[i, j] == GetJewel(newCoordinates.x + 1, newCoordinates.y) 
                        && newCoordinates.x + 2 < GetWidth() && jewels[i, j] == GetJewel(newCoordinates.x + 2, newCoordinates.y))
                    {
                        // Add this move to the list of possible moves
                        possibleMoves.Add(move);
                    }

                    // Check the two jewels to the left
                    if (newCoordinates.x - 1 > 0 && jewels[i, j] == GetJewel(newCoordinates.x - 1, newCoordinates.y)
                        && newCoordinates.x - 2 > 0 && jewels[i, j] == GetJewel(newCoordinates.x - 2, newCoordinates.y))
                    {
                        possibleMoves.Add(move);
                    }

                    // Check the jewels on either side of the swapped jewel, i.e. the only other way a match of three can occur
                    if (newCoordinates.x - 1 > 0 && jewels[i, j] == GetJewel(newCoordinates.x - 1, newCoordinates.y)
                        && newCoordinates.x + 1 < GetWidth() && jewels[i, j] == GetJewel(newCoordinates.x + 1, newCoordinates.y))
                    {
                        possibleMoves.Add(move);
                    }

                    // Reset the jewels to their previous positions
                    SetJewel(oldCoordinates.x, oldCoordinates.y, jewels[i, j]);
                    SetJewel(newCoordinates.x, newCoordinates.y, jewels[i, j - 1]);
                }




                // Swap this jewel with the one below it
                if (j < GetHeight() - 1)
                {
                    // Store the new coordinates and current coordinates so these can be changed back later
                    Vector2 newCoordinates = new Vector2(i, j + 1);
                    Vector2 oldCoordinates = new Vector2(i, j);

                    // Create a new Move instance for this particular move
                    Move move = new Move();
                    move.x = oldCoordinates.x;
                    move.y = oldCoordinates.y;
                    move.direction = MoveDirection.Down;

                    // Set the jewel to be down one space
                    SetJewel(newCoordinates.x, newCoordinates.y, jewels[i, j]);
                    // Set the replaced jewel to be up one space
                    SetJewel(oldCoordinates.x, oldCoordinates.y, jewels[i, j + 1]);

                    // Check if the two jewels to the right of the swapped jewel are the same type, i.e. a match occurs
                    if (newCoordinates.x + 1 < GetWidth() && jewels[i, j] == GetJewel(newCoordinates.x + 1, newCoordinates.y)
                        && newCoordinates.x + 2 < GetWidth() && jewels[i, j] == GetJewel(newCoordinates.x + 2, newCoordinates.y))
                    {
                        // Add this move to the list of possible moves
                        possibleMoves.Add(move);
                    }

                    // Check the two jewels to the left
                    if (newCoordinates.x - 1 > 0 && jewels[i, j] == GetJewel(newCoordinates.x - 1, newCoordinates.y)
                        && newCoordinates.x - 2 > 0 && jewels[i, j] == GetJewel(newCoordinates.x - 2, newCoordinates.y))
                    {
                        possibleMoves.Add(move);
                    }

                    // Check the jewels on either side of the swapped jewel, i.e. the only other way a match of three can occur
                    if (newCoordinates.x - 1 > 0 && jewels[i, j] == GetJewel(newCoordinates.x - 1, newCoordinates.y)
                        && newCoordinates.x + 1 < GetWidth() && jewels[i, j] == GetJewel(newCoordinates.x + 1, newCoordinates.y))
                    {
                        possibleMoves.Add(move);
                    }

                    // Reset the jewels to their previous positions
                    SetJewel(oldCoordinates.x, oldCoordinates.y, jewels[i, j]);
                    SetJewel(newCoordinates.x, newCoordinates.y, jewels[i, j + 1]);
                }




                // Swap this jewel with the one to the left of it
                if (i > 0)
                {
                    // Store the new coordinates and current coordinates so these can be changed back later
                    Vector2 newCoordinates = new Vector2(i - 1, j);
                    Vector2 oldCoordinates = new Vector2(i, j);

                    // Create a new Move instance for this particular move
                    Move move = new Move();
                    move.x = oldCoordinates.x;
                    move.y = oldCoordinates.y;
                    move.direction = MoveDirection.Left;

                    // Set the jewel to be left one space
                    SetJewel(newCoordinates.x, newCoordinates.y, jewels[i, j]);
                    // Set the replaced jewel to be right one space
                    SetJewel(oldCoordinates.x, oldCoordinates.y, jewels[i - 1, j]);

                    // Check if the two jewels below the swapped jewel are the same type, i.e. a match occurs
                    if (newCoordinates.y + 1 < GetHeight() && jewels[i, j] == GetJewel(newCoordinates.x, newCoordinates.y + 1)
                        && newCoordinates.y + 2 < GetHeight() && jewels[i, j] == GetJewel(newCoordinates.x, newCoordinates.y + 2))
                    {
                        // Add this move to the list of possible moves
                        possibleMoves.Add(move);
                    }

                    // Check the two jewels above
                    if (newCoordinates.y - 1 > 0 && jewels[i, j] == GetJewel(newCoordinates.x, newCoordinates.y - 1)
                        && newCoordinates.y - 2 > 0 && jewels[i, j] == GetJewel(newCoordinates.x, newCoordinates.y - 2))
                    {
                        possibleMoves.Add(move);
                    }

                    // Check the jewels on either side of the swapped jewel, i.e. the only other way a match of three can occur
                    if (newCoordinates.y - 1 > 0 && jewels[i, j] == GetJewel(newCoordinates.x, newCoordinates.y - 1)
                        && newCoordinates.y + 1 < GetHeight() && jewels[i, j] == GetJewel(newCoordinates.x, newCoordinates.y + 1))
                    {
                        possibleMoves.Add(move);
                    }

                    // Reset the jewels to their previous positions
                    SetJewel(oldCoordinates.x, oldCoordinates.y, jewels[i, j]);
                    SetJewel(newCoordinates.x, newCoordinates.y, jewels[i - 1, j]);
                }




                // Swap this jewel with the one to the right of it
                if (i < GetWidth() - 1)
                {
                    // Store the new coordinates and current coordinates so these can be changed back later
                    Vector2 newCoordinates = new Vector2(i + 1, j);
                    Vector2 oldCoordinates = new Vector2(i, j);

                    // Create a new Move instance for this particular move
                    Move move = new Move();
                    move.x = oldCoordinates.x;
                    move.y = oldCoordinates.y;
                    move.direction = MoveDirection.Right;

                    // Set the jewel to be left one space
                    SetJewel(newCoordinates.x, newCoordinates.y, jewels[i, j]);
                    // Set the replaced jewel to be right one space
                    SetJewel(oldCoordinates.x, oldCoordinates.y, jewels[i + 1, j]);

                    // Check if the two jewels below the swapped jewel are the same type, i.e. a match occurs
                    if (newCoordinates.y + 1 < GetHeight() && jewels[i, j] == GetJewel(newCoordinates.x, newCoordinates.y + 1)
                        && newCoordinates.y + 2 < GetHeight() && jewels[i, j] == GetJewel(newCoordinates.x, newCoordinates.y + 2))
                    {
                        // Add this move to the list of possible moves
                        possibleMoves.Add(move);
                    }

                    // Check the two jewels above
                    if (newCoordinates.y - 1 > 0 && jewels[i, j] == GetJewel(newCoordinates.x, newCoordinates.y - 1)
                        && newCoordinates.y - 2 > 0 && jewels[i, j] == GetJewel(newCoordinates.x, newCoordinates.y - 2))
                    {
                        possibleMoves.Add(move);
                    }

                    // Check the jewels on either side of the swapped jewel, i.e. the only other way a match of three can occur
                    if (newCoordinates.y - 1 > 0 && jewels[i, j] == GetJewel(newCoordinates.x, newCoordinates.y - 1)
                        && newCoordinates.y + 1 < GetHeight() && jewels[i, j] == GetJewel(newCoordinates.x, newCoordinates.y + 1))
                    {
                        possibleMoves.Add(move);
                    }

                    // Reset the jewels to their previous positions
                    SetJewel(oldCoordinates.x, oldCoordinates.y, jewels[i, j]);
                    SetJewel(newCoordinates.x, newCoordinates.y, jewels[i + 1, j]);
                }
            }
        }

        Move currentBestMove = new Move();
        currentBestMove.priority = 0;

        // Now that all possible matches have been added to the list, the list can be iterated through to find which move caused the most matches
        // Every time a move equals another move in the list, the priority of that move is increased
        for (int i = 0; i < possibleMoves.Count; i++)
        {
            for (int j = 0; j < possibleMoves.Count; j++)
            {
                if (possibleMoves[i].x == possibleMoves[j].x
                    && possibleMoves[i].y == possibleMoves[j].y
                    && possibleMoves[i].direction == possibleMoves[j].direction)
                {
                    // This will happen at least once for each move, as it will match with itself
                    possibleMoves[i].priority++;

                    // If this move priority has a higher priority than the current best move, make it the new best move
                    if (possibleMoves[i].priority > currentBestMove.priority) currentBestMove = possibleMoves[i];
                }
            }
        }

        return currentBestMove;
    }
};

*/