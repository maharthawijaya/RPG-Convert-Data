using Godot;
using System;

public partial class UIManager : Node
{
    [Export]
    private VBoxContainer _buttonParent;
    [Export]
    private Panel _jobDetailsPanel;
    [Export]
    private Label _jobName;
    [Export]
    private Label _jobDescription;
    [Export]
    private Label _jobSkill;

    
    
    public override void _Ready()
	{
        _jobDetailsPanel.Visible = false;
	}

    public void CreateNewButton(Button button) {
        _buttonParent.AddChild(button);
    }

    public void ButtonPressed(string dataName, string dataDescriptions, string[] dataSkills) {
        _jobDetailsPanel.Visible = true;
        _jobName.Text = $"{dataName}";
        _jobDescription.Text = $"{dataDescriptions}";
        _jobSkill.Text = string.Join("\n", dataSkills);
    }
}
