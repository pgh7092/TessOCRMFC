import socket
import os
import io
import os.path
import tesserocr
import time
from PIL import Image

def Main():
	s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
	host = ''
	port = 5007
	sum = 0
	s.bind((host, port))

	s.listen(1)
	print("Waiting for a connection...")

	c, addr = s.accept()
	print("Connection from: " + str(addr))

	if os.path.isfile("image.png"):
        	os.remove("image.png")

	file = open("image.png", "w+b")
	while True:
        	data = c.recv(1024)
		if not data:
			break
		file.write(data)
		file.flush()
	print(tesserocr.file_to_text('image.png'))
	tst = tesserocr.file_to_text('image.png')
	f = open('tess.txt', 'w')
	f.write(tst.encode('utf-8'))
	s.send('tess.txt')
	print("Done.")

	c.close()
	s.close()

if __name__ == "__main__":
	Main()
