Привет, проверяющий!

ОЧЕНЬ ВАЖНЫЙ МОМЕНТ:
Я не расписывал подробно, как работают методы в
XML-комментариях (те, что являются Http-методами 
по понятной причине, а остальные просто потому, что логика совсем не сложная),
написал лишь функционал метода.

Несколько общих важных моментов:
1. При самом первом запуске программы сначала нужно инициализировать списки (иначе
методы будут возвращать сообщение об ошибке с просьбой инициализировать списки)
2. Если вы уже одиножды инициализировали списки(создались соответствующие json-файлы),
то при всех последующих запусках программы будут доступны сразу все методы
3. Все строковые свойства типа Message могут быть из заглавных или строчных латинских
букв, без цифр и служебных знаков(это стоит учесть при добавлении нового пользователя, иначе
программа выдаст сообщение об ошибке и попросит соблюдать необходимый формат)
4. Если удалить json-файлы в процессе работы программы и вызвать какой-нибудь метод,
ничего страшного не произойдет, все будет работать так, будто программа запустилась
в первый раз) 
5. Из доп функционала реализован только 7-й пункт(добавление 
пользователя).
6. Последний метод в контроллере UserController, отвечающий за добавление нового
пользователя в систему, занимает 43 строки, я надеюсь это не станет поводом для отжатия
балла за кодстайл(а вдруг) 

За что отвечают контроллеры:
1. UserController занимается работой с пользователями(выводит список, выводит
пользователя по Email и т.д)
2. MesssageController работает с сообщениями(выводит сообщения от кого-то кому-то и т.д)
3. InitializationController инициализирует списки пользователей и сообщений.

За что отвечают классы:
JsonSerialization отвечает за работу с json-файлами.

За что отвечают модели думаю и так понятно.
