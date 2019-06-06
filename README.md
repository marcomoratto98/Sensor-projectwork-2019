# Sensors
## Installation
### Clone this repository
```
git clone https://github.com/VaporMontey/Sensor-projectwork-2019.git

```
## Configuration
Premessa: tutte le impostazioni vanno cambiate nel file App.config

1. Settare l'indirizzo url delle API 
2. Settare numero linea degli autobus
3. Settare numero totale di autobus

## Operating
Prerequisiti: 
- *Docker* con container di *Redis* nominato `pw-redis`
- *Visual Studio 2019* (o versioni precedenti)
- API con annessi i prerequisiti (vedi readme API)

1. Avviare *Docker*
2. Tramite cmd eseguire la seguente stringa di codice `docker run --name pw-redis -p 6379:6379 -d redis` per avviare il container con all'interno *Redis*
3. Avviare le API con *Visual Studio Code* e annessi prerequisiti
4. Aprire il file *ITS_ProjectWork_II_2018.sln* con *Visual Studio 2019* (o versioni precendenti) ed eseguire prima il *DataReader* e lasciarlo in esecuzione per la creazione di dati esempio.
5. Avviare il *DataSender* per invio dei dati a *Redis*

## Changelog
Introduzione multi-threading e pulizia generale del codice
