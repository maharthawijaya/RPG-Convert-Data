using Godot;
using System;
using System.IO;

public partial class DataManager : Node
{
    private const string CLASSFILEPATH = "Class.csv";

    private string[][] skillData;
	private string[] data;

	private UIManager uiManager;

	public override void _Ready()
	{
		uiManager = GetNode<UIManager>("/root/UIManager");

		data = File.ReadAllLines(CLASSFILEPATH);
		skillData = new string[skillData.Length][];

		for ( int i = 0; i < data.Length; i++ ) {
			string[] dataSplit = data[i].Split(',');
			string[] skills = dataSplit[3].Split(';');

			skillData[i] = new string[skills.Length];

			for ( int j = 0; j < skills.Length; j++ ) {
				skillData[i][j] = skills[j].Trim();
			}

            string[] capturedSkills = skillData[i];
			string capturedId = dataSplit[0];
            string capturedName = dataSplit[1];
            string capturedDescription = dataSplit[2];

            Button btn = new() {
                Text = $"{dataSplit[0]}. {dataSplit[1]}"
            };

            uiManager.CreateNewButton(btn);
            btn.Pressed += () => Btn_Pressed(capturedName, capturedDescription, capturedSkills);
        }
	}

    private void Btn_Pressed(string dataName, string dataDescriptions, string[] dataSkills) {
		uiManager.ButtonPressed(dataName, dataDescriptions, dataSkills);
    }

    public override void _Process(double delta)
	{
	}
}
