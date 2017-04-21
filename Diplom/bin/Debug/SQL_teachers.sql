select 
	pib "Ім'я", 
	disc_name "Предмет", 
	case lectures when 1 then 'Lector' when 0 then 'Not a lector' end "Лектор?",
	case practice when 1 then 'Practitian' when 0 then 'Not a practitian' end "Практик?",
	case labs when 1 then 'Labratorian' when 0 then 'Dont even try' end "Приймає лабораторні"
from Teacher
order by 1;