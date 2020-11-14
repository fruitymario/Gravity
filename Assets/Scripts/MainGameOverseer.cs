using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainGameOverseer : MonoBehaviour
{
    #region enums
    public enum GameState
    {
        PreGame,
        GamePlaying,
        GameComplete,
    }
    #endregion enums

    #region delegate events
    public UnityAction OnGameStateChange;
    #endregion delegate events

    #region static variables
    private static MainGameOverseer instance;

    public static MainGameOverseer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<MainGameOverseer>();
            }
            return instance;
        }
    }
    #endregion static variables

    #region main variables
    public GameState CurrentGameState { get; private set; }
    public PlayerChar MainPlayerChar { get; private set; }
    #endregion main variables

    #region monobehaviour methods
    private void Awake()
    {
        instance = this;
    }
    #endregion monobehaivour methods

    public void SetMainPlayer(PlayerChar Player)
    {
        MainPlayerChar = Player;
    }

    public void SetGameState(GameState NewGameState)
    {
        if (CurrentGameState == NewGameState) return;
        OnGameStateEnd(CurrentGameState);
        OnGameStateStart(NewGameState);
        CurrentGameState = NewGameState;

        OnGameStateChange?.Invoke();
    }

    private void OnGameStateEnd(GameState PreviousGameState)
    {
        switch(PreviousGameState)
        {
            case GameState.PreGame:
                return;
            case GameState.GamePlaying:
                return;
            case GameState.GameComplete:
                return;
        }
    }

    private void OnGameStateStart(GameState NewGameState)
    {
        switch (NewGameState)
        {
            case GameState.PreGame:
                return;
            case GameState.GamePlaying:
                return;
            case GameState.GameComplete:
                return;
        }
    }
}
