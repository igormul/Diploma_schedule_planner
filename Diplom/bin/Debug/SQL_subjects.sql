select 
	disc_name "Предмет",
	course*10 + group_no "Група",
	lectures "Лекції",
	practice "Практичні",
	labs "Лабораторні"
from Discipline;