extends Node

@export var _buttonParent: VBoxContainer
@export var _jobDetailsPanel: Panel
@export var _jobName:Label
@export var _jobDescription:Label
@export var _jobSkill:Label

func _ready():
	_jobDetailsPanel.visible = false

func create_new_button(button):
	_buttonParent.add_child(button)

func button_pressed(data_name, data_description, data_skills):
	_jobDetailsPanel.visible = true
	_jobName.text = str(data_name)
	_jobDescription.text = str(data_description)
	_jobSkill.text = "\n".join(data_skills)
