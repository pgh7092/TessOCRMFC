import socket
import os
import io
import os.path
import tesserocr
from PIL import Image
from mtranslate import translate

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

	print("Image To Text")
	print(tesserocr.file_to_text('image.png'))
	tst = tesserocr.file_to_text('image.png')


	f = open('tess.txt', 'w')
	f.write(tst.encode('utf-8'))s
	f.flush()
	f.close()

	fw = open('trans.txt', 'w')
	f = open('tess.txt', 'r')
	while True:
		fdata = f.readline()
		if not fdata: break;
		fdata = translate(fdata, 'ko')
		print(fdata)
		fw.write(fdata.encode('utf-8'))
		fw.write('\n')

	print("Done.")

	c.close()
	s.close()

if __name__ == "__main__":
	Main()
