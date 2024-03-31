extends Control

const CLASSFILEPATH = "Class.csv"

var skill_data = []
var data = []
@export var ui_manager: Script

func _ready():
	var file = File.new()
	if file.file_exists(CLASSFILEPATH):
		file.open(CLASSFILEPATH, File.READ)
		data = file.get_as_text().split("\n")
		file.close()

		skill_data.resize(data.size())

		for i in range(data.size()):
			var data_split = data[i].split(",")
			var skills = data_split[3].split(";")

			skill_data[i] = skills

			var captured_skills = skill_data[i]
			var captured_id = data_split[0]
			var captured_name = data_split[1]
			var captured_description = data_split[2]

			var btn = Button.new()
			btn.text = captured_id + ". " + captured_name
			ui_manager.create_new_button(btn)

			btn.connect("pressed", self, "_on_button_pressed", [captured_name, captured_description, captured_skills])

func _on_button_pressed(data_name, data_description, data_skills):
	ui_manager.button_pressed(data_name, data_description, data_skills)

func _process(delta):
	pass
