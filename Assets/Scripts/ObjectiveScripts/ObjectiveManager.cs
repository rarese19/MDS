using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveText; // UI Text to display the current objective
    public TextMeshProUGUI description;

    private int currentObjectiveIndex = 0;
    private static List<string> objectives = new List<string> {
        "Get the weapons",
        "Escape the prison",
        "Survive"
    };
    private static List<string> descriptions = new List<string>
    {
        "With month in preparation, you had hidden two guns in one of the prison showers. Go get them, but be carefull to not be detected by the guard.",
        "Amazing! Now exit the building and earn your freedom.",
        "Ah shit... I'm out, good luck."
    };

    void Start()
    {
        UpdateObjective();
    }

    void UpdateObjective()
    {
        if (currentObjectiveIndex < objectives.Count)
        {
            if (objectiveText.text != objectives[currentObjectiveIndex])
            {
                objectiveText.text = objectives[currentObjectiveIndex];
                description.text = descriptions[currentObjectiveIndex];
            }
        }
        else
        {
            objectiveText.text = "You are finally free.";
        }
    }

    public void CompleteObjective()
    {
        currentObjectiveIndex++;
        UpdateObjective();
    }

    public string getCurrentObjective()
    {
        return objectives[currentObjectiveIndex];
    }
}
