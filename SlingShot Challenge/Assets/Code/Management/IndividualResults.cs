﻿using UnityEngine;

using System.Collections;

public class IndividualResults : MonoBehaviour
{
    Texture2D BackGroundImage;

    Button ContinueButton;

    // Use this for initialization
	void Start()
    {
        # region Language

        switch (StateManager.CurrentLanguage)
        {
            case GameLanguage.English:

                BackGroundImage = (Texture2D)Resources.Load("BackGroundImages/IndividualResults");

                break;

            case GameLanguage.Portugues:

                BackGroundImage = (Texture2D)Resources.Load("Telas/ResultadosIndividuais");

                break;
        }

        # endregion

        ContinueButton = new Button("Buttons/Continue" , new Vector2(550 , 475));
	}
	
	// Update is called once per frame
	void Update()
    {
        if (StateManager.IsOnTransition)
        {
            StateManager.Update();
        }
        else
        {
            # region Escape

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GetMenu();
            }

            # endregion

            # region Enter

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                //GetTransformation();

                GetMenu();
            }

            # endregion
        }
	}

    void OnGUI()
    {
        StateManager.DrawBackGroundImage(BackGroundImage);

        ContinueButton.Draw(StateManager.GameSkin.button);

        if (ContinueButton.Clicked)
        {
            //GetTransformation();

            GetMenu();
        }

        StateManager.TransitionEffect();
    }

    void GetMenu()
    {
        GameObject.Destroy(GamePlay.LocalAudio);

        StateManager.ChangeState(GameStates.Menu);
    }

    void GetTransformation()
    {
        StateManager.ChangeState(GameStates.Transformation);
    }
}