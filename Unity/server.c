#include <stdio.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <netdb.h>
#include <stdlib.h>
#include <time.h>
#include <signal.h>

void error(char *msg)
{
    perror(msg);
    exit(1);
}

int main(int argc, char *argv[])
{
     signal(SIGPIPE, SIG_IGN);
     /* Declare stuff */
     int sockfd, newsockfd, portno, clilen;
     char buffer[256];
     struct sockaddr_in serv_addr, cli_addr;
     int n;

     /* Check args */
     if (argc < 2) {
         fprintf(stderr,"ERROR, no port provided\n");
         exit(1);
     }

     srand(time(NULL));
     /* Open socket (Gives us sockfd) */
     sockfd = socket(AF_INET, SOCK_STREAM, 0);
     if (sockfd < 0) 
        error("ERROR opening socket");


     /* Initialize server address (Gives us serv_addr) */
     bzero((char *) &serv_addr, sizeof(serv_addr));
     portno = atoi(argv[1]);

     serv_addr.sin_family = AF_INET;
     serv_addr.sin_addr.s_addr = INADDR_ANY;
     serv_addr.sin_port = htons(portno);

     
     /* Binds socket (using sockfd and serv_addr) */
     if (bind(sockfd, (struct sockaddr *) &serv_addr,
              sizeof(serv_addr)) < 0) 
              error("ERROR on binding");

     /* castle doors open */
    while(1)
    {
        listen(sockfd,5);


        clilen = sizeof(cli_addr);
        newsockfd = accept(sockfd, (struct sockaddr *) &cli_addr, &clilen);

   
//         if (newsockfd < 0) 
//             error("ERROR on accept");

         while(1)
         {
            int r= rand() % 100 + 1 ;
            printf(" %i \n", r);
            bzero(buffer,256);
            // fgets(buffer,255,stdin);
            char str[3];
            sprintf(str, "%d", r); 
            strcpy(buffer, str);
          
	    n = write(newsockfd,buffer,strlen(buffer));
	    
             if (n < 0) 
                 break;
            bzero(buffer,256);
            n = read(newsockfd,buffer,255);
         //   if (n < 0) 
           //      error("ERROR reading from socket");
           // printf("%s\n",buffer);       
  
        }
    }
}
