#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>

const char* ssid = "home";
const char* password = "Davin1358";

ESP8266WebServer server(80);

void handleSetGPIO2() {
  String value = server.arg("value");
  if (value == "1") {
    digitalWrite(2, HIGH);
    server.send(200, "text/plain", "GPIO2 set to HIGH");
  } else if (value == "0") {
    digitalWrite(2, LOW);
    server.send(200, "text/plain", "GPIO2 set to LOW");
  } else {
    server.send(400, "text/plain", "Invalid value");
  }
}

void setup() {
  Serial.begin(9600);
  pinMode(2, OUTPUT); // Set GPIO2 as output
    Serial.println("Connecting to WiFi...");
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(5000);
    Serial.println("Connecting to WiFi...");
  }
  Serial.println("Connected to WiFi");
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());
  
  server.on("/setGPIO2", handleSetGPIO2);
  server.begin();
}

void loop() {
  server.handleClient();
}