select 
	Id_room "Аудиторія",
	case "type" when 1 then 'Lecture' when 2 then 'Practice' when 3 then 'Lab' end "Тип",
	places "Кільсть місць"	
from Rooms
order by 1;