using System.Collections.Generic;
using Code.Game;
using Code.Player;
using Configs;
using UI;


public class GameInit
{
    public GameInit(Controller controller, ConfigsHolder configs, 
        PlayerView playerView, TorchPanel torchPanel, List<Water> water, 
        DeadPanel deadPanel, MainMenu mainMenu, List<Torch> torches, End end)
    {
        var player = new PLayerController(playerView);
        var torchController = new UIController(torchPanel, water, deadPanel, mainMenu, playerView, torches, end);

        controller.Add(player);
        controller.Add(torchController);
    }
}