create table films
(
    title              text,
    director           text,
    production_country text,
    genre              text,
    production_year    integer,
    image_path         text,
    id                 integer not null
        constraint films_pk
            primary key,
    price              numeric
        constraint films_pk_2
            check ((price > (0)::numeric) AND (price < (100)::numeric))
);

alter table films
    owner to postgres;

INSERT INTO public.films (title, director, production_country, genre, production_year, image_path, id, price) VALUES ('DWUNASTU GNIEWNYCH LUDZI', 'Sidney Lumet', 'USA', 'Dramat', 1957, 'DWUNASTU GNIEWNYCH LUDZI.jpg', 10, 48);
INSERT INTO public.films (title, director, production_country, genre, production_year, image_path, id, price) VALUES ('WŁADCA PIERŚCIENI: POWRÓT KRÓLA', 'Peter Jackson', 'Nowa Zelandia / USA', 'Fantasy', 2003, 'WŁADCA PIERŚCIENI POWRÓT KRÓLA.jpg', 6, 36);
INSERT INTO public.films (title, director, production_country, genre, production_year, image_path, id, price) VALUES ('ZIELONA MILA', 'Frank Darabont', 'USA', 'Dramat', 1999, 'ZIELONA MILA.jpg', 1, 65);
INSERT INTO public.films (title, director, production_country, genre, production_year, image_path, id, price) VALUES ('LOT NAD KUKUŁCZYM GNIAZDEM', 'Miloš Forman', 'USA', 'Dramat', 1975, 'LOT NAD KUKUŁCZYM GNIAZDEM.jpg', 7, 7);
INSERT INTO public.films (title, director, production_country, genre, production_year, image_path, id, price) VALUES ('NIETYKALNI', 'Olivier Nakache', 'Francja', 'Biograficzny', 2011, 'NIETYKALNI.jpg', 3, 21);
INSERT INTO public.films (title, director, production_country, genre, production_year, image_path, id, price) VALUES ('SKAZANI NA SHAWSHANK', 'Frank Darabont', 'USA', 'Dramat', 1994, 'SKAZANI NA SHAWSHANK.jpg', 2, 11.5);
INSERT INTO public.films (title, director, production_country, genre, production_year, image_path, id, price) VALUES ('LISTA SCHINDLERA', 'Steven Spielberg', 'USA', 'Wojenny', 1994, 'LISTA SCHINDLERA.jpg', 9, 21);
INSERT INTO public.films (title, director, production_country, genre, production_year, image_path, id, price) VALUES ('OJCIEC CHRZESTNY', 'Francis Ford Coppola', 'USA', 'Gangsterski', 1972, 'OJCIEC CHRZESTNY.jpg', 5, 54);
INSERT INTO public.films (title, director, production_country, genre, production_year, image_path, id, price) VALUES ('OJCIEC CHRZESTNY II', 'Francis Ford Coppola', 'USA', 'Gangsterski', 1974, 'OJCIEC CHRZESTNY II.jpg', 8, 73);
INSERT INTO public.films (title, director, production_country, genre, production_year, image_path, id, price) VALUES ('FORREST GUMP', 'Robert Zemeckis', 'USA', 'Dramat', 1994, 'FORREST GUMP.jpg', 4, 51);